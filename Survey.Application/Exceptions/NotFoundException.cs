using System;

namespace Survey.Application.Exceptions // <- Dikkat! Exceptions (çoğul)
{
    public class NotFoundException : Exception
    {
        public NotFoundException(string message) : base(message) { }
    }
}
