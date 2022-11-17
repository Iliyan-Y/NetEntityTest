namespace NetEntity.Models;

public class CustomApiResponse
{
  public string status { get; set; }
  public object data { get; set; }

  public CustomApiResponse(string status, object data = null)
  {
    this.status = status;
    this.data = data;
  }
}