﻿
public interface ICar
{
    string Model { get; }
    string Driver { get; set; }
    string UseBrakes();
    string UseGasPedal();
}

