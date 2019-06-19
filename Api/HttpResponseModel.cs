using System.Net;

namespace Api
{
    /// <summary>
    /// 请求响应实体.
    /// </summary>
    public class HttpResponseModel : Pager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseModel"/> class.
        /// </summary>
        /// <param name="data">data.</param>
        /// <param name="pager">pager.</param>
        public HttpResponseModel(object data, Pager pager) : this()
        {
            Data = data;
            PageSize = pager.PageSize;
            PageIndex = pager.PageIndex;
            TotalCount = pager.TotalCount;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="HttpResponseModel"/> class.
        /// 请求响应实体类.
        /// </summary>
        public HttpResponseModel()
        {
            Code = (int)HttpStatusCode.OK;
            Message = "操作成功";
        }

        /// <summary>
        /// 响应代码.
        /// </summary>
        public int Code { get; set; }

        /// <summary>
        /// 响应消息内容.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 返回的响应数据.
        /// </summary>
        public object Data { get; set; }

        /// <summary>
        /// 设置响应状态为成功.
        /// </summary>
        /// <param name="message">message.</param>
        public void SetSuccess(string message = "成功")
        {
            Code = (int)HttpStatusCode.OK;
            Message = message;
        }

        /// <summary>
        /// 设置响应状态为失败.
        /// </summary>
        /// <param name="message">message.</param>
        public void SetFailed(string message = "失败")
        {
            Message = message;
            Code = 999;
        }

        /// <summary>
        /// 设置响应状态为错误.
        /// </summary>
        /// <param name="message">message.</param>
        public void SetError(string message = "错误")
        {
            Code = (int)HttpStatusCode.InternalServerError;
            Message = message;
        }

        /// <summary>
        /// 设置响应状态为未知资源.
        /// </summary>
        /// <param name="message">message.</param>
        public void SetNotFound(string message = "未知资源")
        {
            Code = (int)HttpStatusCode.NotFound;
            Message = message;
        }

        /// <summary>
        /// 设置响应状态为无权限.
        /// </summary>
        /// <param name="message">message.</param>
        public void SetNoPermission(string message = "无权限")
        {
            Code = (int)HttpStatusCode.Unauthorized;
            Message = message;
        }

        /// <summary>
        /// 设置响应数据.
        /// </summary>
        /// <param name="data">data.</param>
        /// <param name="total">total.</param>
        public void SetData(object data, int total = 0)
        {
            Data = data;
            TotalCount = total;
        }
    }

    public class Pager
    {
        private const int DefaultPageSize = 10;
        private const int DefaultPageIndex = 1;

        /// <summary>
        /// 分页大小.
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 当前页码.
        /// </summary>
        public int PageIndex { get; set; }

        public int TotalCount { get; set; }

        public static Pager CreateDefaultInstance()
        {
            Pager pager = new Pager
            {
                PageSize = DefaultPageSize,
                PageIndex = DefaultPageIndex,
            };

            return pager;
        }
    }
}
