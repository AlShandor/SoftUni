﻿
using System;
using BashSoft;

public abstract class Command
{
    private string input;
    private string[] data;
    private Tester judge;
    private StudentsRepository repository;
    private IOManager inputOutputManager;

    public Command(string input, string[] data, Tester judge, StudentsRepository repository, IOManager inputOutputManager)
    {
        this.Input = input;
        this.Data = data;
        this.judge = judge;
        this.repository = repository;
        this.inputOutputManager = inputOutputManager;
    }

    public string Input
    {
        get { return input; }
        private set
        {
            if (string.IsNullOrEmpty(value))
            {
                throw new InvalidStringException();
            }
            input = value;
        }
    }

    public string[] Data
    {
        get { return data; }
        private set
        {
            if (value == null || value.Length == 0)
            {
                throw new NullReferenceException();
            }
            data = value;
        }
    }

    protected Tester Judge => this.judge;

    protected StudentsRepository Repository => this.repository;

    protected IOManager InputOutputMenager => this.inputOutputManager;

    public abstract void Execute();
}

