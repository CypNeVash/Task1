using System;
using System.Collections.Generic;
using System.Text;

namespace Blogs.Model
{
    /// <summary>
    /// Base сlass for all entities
    /// </summary>
    public class BaseEntity
    {
        /// <summary>
        /// Represents a globally unique identifier (GUID).
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();
    }
}
