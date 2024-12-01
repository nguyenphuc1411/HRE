namespace HRE.WebAPI.Attributes
{
    [AttributeUsage(AttributeTargets.Method)]
    public class RequiredPermissionAttribute:Attribute
    {
        public string PermissionName { get; }
        public RequiredPermissionAttribute(string permissionName)
        {
            PermissionName = permissionName;
        }
    }
}
