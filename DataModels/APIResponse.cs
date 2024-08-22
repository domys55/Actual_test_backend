namespace Model_lib
{
    public class APIResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public int StatusCode { get; set; }

        public static APIResponse<T> Ok(T data)
        {
            return new APIResponse<T>
            {
                Data = data,
                Success = true,
                StatusCode = 200
            };
        }

        public static APIResponse<T> OkNoData()
        {
            return new APIResponse<T>
            {
                Success = true,
                StatusCode = 200
            };
        }

        public static APIResponse<T> NotFound()
        {
            return new APIResponse<T>
            {
                Success = false,
                StatusCode = 404
            };
        }

        public static APIResponse<T> ServerError()
        {
            return new APIResponse<T>
            {
                Success = false,
                StatusCode = 500,
                ErrorMessage = "Internal server error!"
            };
        }

        
    }
}
