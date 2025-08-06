using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Entities;

public enum TaskItemStatus
{
    Pending,      // Tarea creada pero no iniciada
    InProgress,   // Tarea que se está realizando
    Completed,    // Tarea finalizada
    Overdue,      // Venció la fecha límite sin completarse
    Cancelled     // Tarea anulada o desestimada
}
