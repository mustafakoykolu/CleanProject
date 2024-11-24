using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanProject.Application.Exceptions;

public class NotFoundException(string name, object key) : Exception($"{name} ({key}) was not found")
{
}
