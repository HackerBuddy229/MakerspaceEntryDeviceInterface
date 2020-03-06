using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;

namespace MakerSpaceEntryInterface.Services
{
    public static class LocalConfigurationServices
    {

        private static string AdminKeyFileName = nameof(AdminKeyFileName) + ".key";




        public static string GetAdminKey()
        {
            string adminKey;

            try
            {
                using (var streamReader = new StreamReader(AdminKeyFileName))
                {
                    adminKey = streamReader.ReadLine();
                }
            } catch (Exception e) {
                return null;
            }

            return adminKey;
        }
    }
}
