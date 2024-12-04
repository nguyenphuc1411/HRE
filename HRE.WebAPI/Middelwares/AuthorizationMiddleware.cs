using HRE.Application.Interfaces;
using HRE.WebAPI.Attributes;
using System.Security.Claims;

namespace HRE.WebAPI.Middelwares
{
    public class AuthorizationMiddleware
    {
        private readonly RequestDelegate _next;

        public AuthorizationMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context, IUserService userService)
        {          
            // Lấy quyền yêu cầu từ endpoint metadata
            var requiredPermission = context.GetEndpoint()?.Metadata
                .GetMetadata<RequiredPermissionAttribute>()?.PermissionName;

            if (!string.IsNullOrEmpty(requiredPermission))
            {
                // Lấy userID từ context
                var userID = context.User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userID))
                {
                    context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                    await context.Response.WriteAsync("User ID not found.");
                    return;
                }
                var userPermissions = await userService.GetRolePermissions(int.Parse(userID));
                if (userPermissions.Contains(requiredPermission))
                {
                    await _next(context);
                }
                else
                {
                    // Không có quyền, trả về lỗi 403
                    context.Response.StatusCode = StatusCodes.Status403Forbidden;
                    await context.Response.WriteAsync("You do not have permission to access this resource.");
                }
            }
            else
            {
                await _next(context);
            }
        }

    }
}
