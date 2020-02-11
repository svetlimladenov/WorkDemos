using System;

namespace WebApi.Data
{
    public abstract class BaseDbModel<T>
    {
        public T Id { get; set; }

        public DateTime CreatedOn { get; set; } = DateTime.UtcNow;
    }
}