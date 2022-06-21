using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RooftopCareerSwitchCallenge.Model
{
  class TokenDTO
  {
    public string token { get; set; }
  }

  /// <summary>
  /// Listado de bloques para procesar
  /// </summary>
  class BlocksDTO
  {
    public string[] data { get; set; }

    public int chunkSize { get; set; }

    public int length { get; set; }
  }
}
