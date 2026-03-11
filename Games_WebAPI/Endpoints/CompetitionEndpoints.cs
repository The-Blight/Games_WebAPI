using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Games_WebAPI.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Games_WebAPI.Endpoints;

public static class CompetitionEndpoints
{
    // public static RouteGroupBuilder MapCompetitionEndpoints(this IEndpointRouteBuilder app)
    // {
    //     var group = app.MapGroup("/api/competitions")
    //         .WithTags("competitions"); 
    //     
    // }
    //


    public static IResult GetAll(List<Competition> competitions) => competitions.Count != 0
        ? Results.Ok(competitions)
        : Results.NoContent();

    public static IResult GetById(Guid id, List<Competition> competitions)
    {
        var foundElement = competitions.FirstOrDefault(c => c.Id == id);
        return foundElement == null
            ? Results.NotFound()
            : Results.Ok(foundElement);
    }


    public static IResult CreateCompetition(Competition competition, List<Competition> competitions)
    {
        if (competition.Date.Date <= DateTime.Now.Date) return Results.BadRequest();

        var newCompetition = competition with { Id = Guid.NewGuid() };

        competitions.Add(competition);
        return Results.Ok();
    }

    public static IResult UpdateById() => Results.Ok(); 

}