using System;
using System.Collections.Generic;
using System.Text;

namespace Services.Commands.Items
{
    public class ResponseItemDto
    {
        public int Id { get; }
        public ResponseItemDto(int id)
        {
            Id = id;
        }
    }
}
