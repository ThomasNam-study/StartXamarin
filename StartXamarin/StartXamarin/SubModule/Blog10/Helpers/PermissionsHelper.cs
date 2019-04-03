using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;

namespace StartXamarin.SubModule.Blog10.Helpers
{
    public class PermissionsHelper
    {
        public static async Task<PermissionStatus> GetPermission(Permission permissionType)
        {
            // added using Plugin.Permissions;
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(permissionType);
            if (status != PermissionStatus.Granted)
            {
                // This is the actual permission request
                var results = await CrossPermissions.Current.RequestPermissionsAsync(permissionType);
                if (results.ContainsKey(permissionType))
                    status = results[permissionType];
            }

            return status;
        }
    }
}
