﻿namespace DoctorAppointment.Data.Entities;

public class Appointment
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public DateTime AppointmentDate { get; set; }
}
