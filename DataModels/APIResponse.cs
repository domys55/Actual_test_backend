namespace Model_lib
{
    public class APIResponse<T>
    {
        public T? Data { get; set; }
        public bool Success { get; set; }
        public string? ErrorMessage { get; set; }
        public int StatusCode { get; set; }
        public int RecordCount { get; set; }

        public static APIResponse<T> Ok(T data)
        {
            return new APIResponse<T>
            {
                Data = data,
                Success = true,
                StatusCode = 200
            };
        }

        public static APIResponse<T> OkRecordCount(T data,int cnt)
        {
            return new APIResponse<T>
            {
                Data = data,
                Success = true,
                RecordCount=cnt,
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
                StatusCode = 404,
                ErrorMessage = "Record not found!"
            };
        }

        public static APIResponse<T> PhoneExists()
        {
            return new APIResponse<T>
            {
                Success = false,
                StatusCode = 405,
                ErrorMessage = "Phone number inserted before and is in use."
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
