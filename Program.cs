using RooftopCareerSwitchCallenge.Model;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace RooftopCareerSwitchCallenge
{
  class Program
  {

    public static string baseAddress = "https://rooftop-career-switch.herokuapp.com";

    public static string email = "gastonfarru@gmail.com";

    public static JavaScriptSerializer js = new JavaScriptSerializer();

    /// <summary>
    /// 
    /// </summary>
    /// <param name="param"></param>
    static void Main(string[] param)
    {

      TokenDTO tokenEntity = GetToken();


      BlocksDTO blocksEntity = GetListBlocks(tokenEntity);


    }

    /// <summary>
    /// Metodo para recuperar el token 
    /// </summary>
    /// <returns></returns>
    static TokenDTO GetToken()
    {
      var tokenResult = System.Threading.Tasks.Task.Run(() => CallAPIGet(baseAddress, string.Format("/Token?email={0}", email)));
      tokenResult.Wait();

      TokenDTO tokenDTO = js.Deserialize<TokenDTO>(tokenResult.Result.ToString());

      return tokenDTO;
    }

    /// <summary>
    /// Recupera los bloques del TOKEN
    /// </summary>
    /// <param name="tokenEntity"></param>
    /// <returns></returns>
    static BlocksDTO GetListBlocks(TokenDTO tokenEntity)
    {
      var blockResult = System.Threading.Tasks.Task.Run(() => CallAPIGet(baseAddress, string.Format("/blocks?token={0}", tokenEntity.token)));
      blockResult.Wait();

      BlocksDTO blocksDTO = js.Deserialize<BlocksDTO>(blockResult.Result.ToString());

      return blocksDTO;
    }

    #region Private

    /// <summary>
    /// Generic GET API
    /// </summary>
    /// <param name="baseAddress"></param>
    /// <param name="getAddress"></param>
    /// <returns></returns>
    static async Task<string> CallAPIGet(string baseAddress, string getAddress)
    {
      string context = "";

      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri(baseAddress);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // New code:
        HttpResponseMessage response = await client.GetAsync(getAddress);
        if (response.IsSuccessStatusCode)
        {
          context = await response.Content.ReadAsStringAsync();
        }
      }

      return context;
    }

    /// <summary>
    /// Generic POST API
    /// </summary>
    /// <param name="baseAddress"></param>
    /// <param name="getAddress"></param>
    /// <returns></returns>
    static async Task<string> CallAPIPost(string baseAddress, string getAddress)
    {
      string context = "";

      using (var client = new HttpClient())
      {
        client.BaseAddress = new Uri(baseAddress);
        client.DefaultRequestHeaders.Accept.Clear();
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        // New code:
        HttpResponseMessage response = await client.GetAsync(getAddress);
        if (response.IsSuccessStatusCode)
        {
          context = await response.Content.ReadAsStringAsync();
        }
      }

      return context;
    }

    #endregion Private
  }
}
