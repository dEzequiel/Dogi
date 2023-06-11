namespace Domain.Enums;

/// <summary>
/// Options representing Http requests.
/// </summary>
public enum HttpStatusCode
{
    Continue = 100,
    SwitchingProtocols = 101,
    Ok = 200,
    Created = 201,
    Accepted = 202,
    NoContent = 204,
    BadRequest = 400,
    Unauthorized = 401,
    PaymentRequired = 402,
    Forbidden = 403,
    NotFound = 404,
    InternalServerError = 500,
    UnprocessableEntity = 422
}