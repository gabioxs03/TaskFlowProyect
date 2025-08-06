using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskFlow.Domain.Entities;

namespace TaskFlow.Application.Dtos;

public static class TaskItemModel
{
    public record TaskItemRequest(
        string Title,
        string Description,
        TaskItemPriority Priority,
        Guid UserId
    );
    public record TaskItemResponse(
        Guid Id,
        string Title,
        string Description,
        string Status,
        string Priority,
        DateTime CreatedAt,
        Guid UserId
    );
}    
