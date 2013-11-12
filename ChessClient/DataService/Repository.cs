using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web;
using Newtonsoft.Json;

namespace ChessClient.DataService {
    public class RepositoryResult {
        public Exception Exception { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public bool IsSuccessStatusCode { get; set; }
    }

    public class RepositoryResult<T> : RepositoryResult {
        public T Value { get; set; }
    }

    public class RepositoryBase {
        protected const string xmlContentType = "text/xml";
        protected const string jsonContentType = "application/json";
        protected const string urlFormat = "{0}/{1}{2}";
        protected static readonly MediaTypeWithQualityHeaderValue mediaType = new MediaTypeWithQualityHeaderValue(xmlContentType);
        protected readonly string name;
        protected readonly string baseUrl;
        public RepositoryBase(string name, string baseUrl) {
            this.name = name;
            this.baseUrl = baseUrl.TrimEnd('/');
        }
    }

    public class Repository<TDto> : RepositoryBase where TDto : class {
        public Repository(string name, string baseUrl)
            : base(name, baseUrl) {
        }

        protected string GetUrl(string parameters) {
            return string.Format(urlFormat, baseUrl, name, parameters);
        }
        protected RepositoryResult<TOtherDto> Get<TOtherDto>(string url) {
            using(var httpClient = new HttpClient()) {
                httpClient.DefaultRequestHeaders.Accept.Add(mediaType);
                TOtherDto value = default(TOtherDto);
                HttpStatusCode code = HttpStatusCode.BadRequest;
                Exception exception = null;
                bool isSuccessStatusCode = false;
                try {
                    var responseTask = httpClient.GetAsync(url);
                    responseTask.Wait();
                    var response = responseTask.Result;
                    isSuccessStatusCode = response.IsSuccessStatusCode;
                    if(isSuccessStatusCode) {
                        try {
                            var readTask = response.Content.ReadAsStreamAsync();
                            readTask.Wait();
                            value = (TOtherDto)new DataContractSerializer(typeof(TOtherDto)).ReadObject(readTask.Result);
                            code = HttpStatusCode.OK;
                        } catch(Exception ex) {
                            exception = ex;
                        }
                    }
                } catch(Exception ex) {
                    exception = ex;
                }
                return new RepositoryResult<TOtherDto> {
                    Value = value,
                    StatusCode = code,
                    Exception = exception,
                    IsSuccessStatusCode = isSuccessStatusCode
                };
            }
        }
        public RepositoryResult<TDto> Add(TDto data) {
            using(var httpClient = new HttpClient()) {
                using(var resultStream = new MemoryStream()) {
                    new DataContractJsonSerializer(typeof(TDto)).WriteObject(resultStream, data);
                    resultStream.Seek(0, SeekOrigin.Begin);
                    StringContent content = new StringContent(new StreamReader(resultStream).ReadToEnd(), Encoding.UTF8, jsonContentType);
                    var responseTask = httpClient.PostAsync(GetUrl(null), content);
                    TDto value = null;
                    responseTask.Wait();
                    var response = responseTask.Result;
                    Exception exception = null;
                    bool isSuccessStatusCode = response.IsSuccessStatusCode;
                    if(isSuccessStatusCode) {
                        try {
                            var readTask = response.Content.ReadAsStringAsync();
                            readTask.Wait();
                            value = JsonConvert.DeserializeObject<TDto>(readTask.Result);
                        } catch(Exception ex) {
                            exception = ex;
                        }
                    }
                    return new RepositoryResult<TDto> {
                        Value = value,
                        StatusCode = response.StatusCode,
                        IsSuccessStatusCode = isSuccessStatusCode,
                        Exception = exception
                    };
                }
            }
        }
        public RepositoryResult Update(TDto data) {
            return Update(data, GetUrl(null));
        }
        protected RepositoryResult Update<TOtherDto>(TOtherDto data, string url) where TOtherDto : class {
            using(var httpClient = new HttpClient())
            using(var contentStream = new MemoryStream()) {
                new DataContractJsonSerializer(typeof(TOtherDto)).WriteObject(contentStream, data);
                contentStream.Seek(0, SeekOrigin.Begin);
                StringContent content = new StringContent(new StreamReader(contentStream).ReadToEnd(), Encoding.UTF8, jsonContentType);
                var responseTask = httpClient.PutAsync(url, content);
                responseTask.Wait();
                var response = responseTask.Result;
                return new RepositoryResult {
                    StatusCode = response.StatusCode,
                    IsSuccessStatusCode = response.IsSuccessStatusCode,
                    Exception = null
                };
            }
        }
        public RepositoryResult Delete(string url) {
            using(var httpClient = new HttpClient()) {
                var resultTask = httpClient.DeleteAsync(url);
                resultTask.Wait();
                var response = resultTask.Result;
                return new RepositoryResult {
                    StatusCode = response.StatusCode,
                    IsSuccessStatusCode = response.IsSuccessStatusCode
                };
            }
        }

    }
}