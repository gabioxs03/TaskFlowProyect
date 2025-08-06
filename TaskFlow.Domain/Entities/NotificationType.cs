using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskFlow.Domain.Entities;

public enum NotificationType
{
    None,
    TaskCreated,   // Notificación cuando se crea una tarea
    TaskUpdated,   // Notificación cuando se actualiza una tarea
    TaskDeleted,
    TaskAssigned,  // Notificación cuando se asigna una tarea a un usuario
    TaskCompleted, // Notificación cuando se completa una tarea
    TaskOverdue,   // Notificación cuando una tarea está vencida
    TaskCancelled, // Notificación cuando una tarea es cancelada
    UserMentioned, // Notificación cuando un usuario es mencionado en un comentario
    CommentAdded,  // Notificación cuando se agrega un comentario a una tarea
    CommentUpdated, // Notificación cuando se actualiza un comentario en una tarea
    CommentDeleted, // Notificación cuando se elimina un comentario de una tarea
    UserAssigned,  // Notificación cuando un usuario es asignado a una tarea
    UserRemoved,   // Notificación cuando un usuario es eliminado de una tarea
    TaskPriorityChanged, // Notificación cuando se cambia la prioridad de una tarea
    TaskStatusChanged,   // Notificación cuando se cambia el estado de una tarea
    TaskDueDateChanged,  // Notificación cuando se cambia la fecha de vencimiento de una tarea
    TaskDueTimeChanged, // Notificación cuando se cambia la hora de vencimiento de una tarea
    TaskReminderSet,      // Notificación cuando se establece un recordatorio para una tarea
    TaskReminderUpdated,  // Notificación cuando se actualiza un recordatorio de tarea
    TaskReminderAssigned,
    TaskReminderCompleted,
    TaskReminderCancelled,
    TaskReminderOverdue,  // Notificación cuando un recordatorio de tarea está vencido
    TaskReminderDeleted,  // Notificación cuando se elimina un recordatorio de tarea
    TaskReminderTimeChanged, // Notificación cuando se cambia la hora de un recordatorio de tarea
    TaskReminderDateChanged, // Notificación cuando se cambia la fecha de un recordatorio de tarea
    TaskReminderNotification, // Notificación cuando se envía una notificación de recordatorio de tarea

}
