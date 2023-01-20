using FastEndpoints;
using MinimalApi.FastEndpoins.DTOs.Month.Requests;
using MinimalApi.FastEndpoins.DTOs.Month.Responses;

namespace MinimalApi.FastEndpoins.Endpoints.Month;

public class MonthEndpoint : Endpoint<MonthIndexRequest, MonthNameResponse>
{
    List<string> Months = new() {
        "Jan","Feb","Mar","Apr","May","Jun","Jul","Aug","Sep","Oct","Nov","Dec"
    };
    public override void Configure()
    {
        //Verbs(Http.GET);
        Get("months/{monthIndex}");
        AllowAnonymous(Http.GET);
        Description(x => x.WithName("GetMonthByIndex"));
        Summary(s =>
        {
            s.Summary = "This method get the name of months";
            s.Description = "This method get the name of months based on inputed index or get all months if index is zero";
            //s.ExampleRequest = new MonthIndexRequest { MonthIndex = 4 };
            //s.ResponseExamples[200] = new MonthNameResponse { MonthNames = new[] { "Apr" } };
            s.Responses[200] = "Every thing is Ok";
            s.Responses[403] = "Somthing went wrong";
        });
    }

    public override async Task HandleAsync(MonthIndexRequest req, CancellationToken ct)
    {
        await SendAsync(new MonthNameResponse()
        {
            MonthNames = req.MonthIndex == 0 ? Months : new List<string>() { Months.ElementAt(req.MonthIndex - 1) }
        });
    }

    //public override async Task HandleAsync(CancellationToken ct)
    //{
    //    int monthIndex = Route<int>("monthIndex");
    //    await SendAsync(new MonthNameResponse()
    //    {
    //        MonthNames = (monthIndex == 0) ? Months : new List<string>() { Months.ElementAt(monthIndex - 1) }
    //    });
    //}
}
