using System;
using System.Collections.Generic;
using System.Text;

namespace Department.Interface
{
    /// <summary>
    /// Interface IGetAuthList
    /// Each Department should inheirt from this interface and register it.
    /// </summary>
    public interface IGetAuthList
    {
        /// <summary>
        /// Get the teacher's Authority List via the ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        System.Web.UI.WebControls.TreeView GetTeacherAuthorityList(String ID);

        /// <summary>
        /// Get the Student's Authority List via the ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        System.Web.UI.WebControls.TreeView GetStudentAuthorityList(String ID);

        /// <summary>
        /// Directly set a teacher to be the department's administrator.
        /// </summary>
        /// <param name="ID">The Teacher's ID</param>
        /// <returns>The state of the operation.</returns>
        Boolean SetAsAdmin(String ID);
    }
}
