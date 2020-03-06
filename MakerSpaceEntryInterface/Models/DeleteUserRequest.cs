using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MakerSpaceEntryInterface.Models
{
    public class DeleteUserRequest
    {

        public string Username { get; set; }
        public string AdminKey { get; set; }
    }
}
