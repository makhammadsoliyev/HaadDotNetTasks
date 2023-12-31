﻿using ExpenseTracker.Models;

namespace ExpenseTracker.Interfaces;

public interface IExpenseService
{
    Expense Add(Expense expense);
    Expense GetById(int id);
    Expense Update(int id, Expense expense);
    bool Delete(int id);
    List<Expense> GetAll();
}
