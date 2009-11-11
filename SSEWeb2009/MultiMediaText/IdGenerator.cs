using System;
using System.Collections.Generic;
using System.Text;

namespace SysCom
{
    /// <summary>
    /// Provide the method to generate an Id.
    /// This Id will be unique.
    /// @Author: Push
    /// </summary>
    public class IdGenerator
    {
        /// <summary>
        /// Provide the method to generate an Id
        /// </summary>
        /// <returns>The Id</returns>
        static public String GenerateId()
        {
            return Guid.NewGuid().ToString().Replace("-", "");
        }
    }
}
