﻿using System;
using System.Collections.Generic;
using System.Linq;
using MyLittleBeaconOpgave.Models;
using SQLite;
using Xamarin.Forms;

namespace MyLittleBeaconOpgave.Data
{
    public class SalesOrderController
    {
        static object locker = new object();
        SQLiteConnection database;

        public SalesOrderController()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<SalesOrder>();
        }

        public List<SalesOrder> tableListSalesOrder;

        public List<SalesOrder> GetSalesOrder()
        {
            lock (locker)
            {
                if (database.Table<SalesOrder>().Count() == 0)
                {
                    return null;
                }
                else
                {
                    return tableListSalesOrder = database.Table<SalesOrder>().ToList<SalesOrder>();

                }

            }
        }
    }
}
