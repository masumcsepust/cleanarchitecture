
using ErrorOr;

namespace cleanarchitecture.Domain.Common.Errors;
public static partial class Errors
{
    public static class Authentication {
        // public static Error InvalidCredential => Error.Conflict(
        //     code: "Auth.InvalidCred",
        //     description: "Invalid credentials." 
        // );
        public static Error InvalidCredential => Error.Validation(
            code: "Auth.InvalidCred",
            description: "Invalid credentials." 
        );
    }
}