namespace MyWebServer.Enums
{
    public enum ResponseStatusCode
    {
        Continue = 100,
        OK = 200,
        Created = 201,
        Accepted = 202,
        MovedPermanently = 301,
        BadRequest = 400,
        Unauthorized = 401,
        Forbidden = 403,
        NotFound = 404,
        MethodNotAllowed = 405,
        InternalServerError = 500,
        NotImplemented = 501,
        BadGateway = 502,
    }
}