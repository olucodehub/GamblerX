using System.ComponentModel.DataAnnotations;

namespace GamblerX.Contracts.Persistence;
public record BettingUpdateRequest(
    string EventName,
    DateTime EventTime,
    string EventImageUrl);



    
  