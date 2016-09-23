﻿using IoTScheduler.Net.Pcl.Database;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace IoTScheduler.Net
{
    public sealed class IoTScheduler
    {
        #region Properties

        #region Private

        //IotSchedulerDatabase _database;

        #endregion

        #region Public

        #endregion

        #endregion

        #region Constructors

        public IoTScheduler()
        {
            //_database = new IotSchedulerDatabase();
        }

        #endregion

        #region Methods

        Timer timer;

        /// <summary>
        /// Adds a task to the scheduler
        /// </summary>
        /// <param name="task">The task to add to the scheduler</param>
        /// <returns>Returns a AddTaskResult with all relevant information</returns>
        public AddTaskResult AddTask(IoTSchedulerTask task)
        {
            Debug.WriteLine("IoTScheduler: Adding task");

            
            DateTime current = DateTime.Now;
            TimeSpan timeToGo = task.StartTime - current.TimeOfDay;
            if (timeToGo < TimeSpan.Zero)
            {
                Debug.WriteLine("IoTScheduler: Too late");
                return new AddTaskResult();
            }

            Debug.WriteLine("IoTScheduler: Adding task in " + timeToGo.TotalSeconds);

            timer = new System.Threading.Timer(x =>
            {
                Debug.WriteLine("IoTScheduler: Firing task");
                task.FireCallback();
            }, null, timeToGo, Timeout.InfiniteTimeSpan);

            return new AddTaskResult();
        }

        /// <summary>
        /// Initializes the scheduler
        /// </summary>
        /// <returns></returns>
        public bool Initialize()
        {
            //_database.Initialize();
            return true;
        }

        /// <summary>
        /// Removes a task from the scheduler
        /// </summary>
        /// <param name="taskId"></param>
        /// <returns></returns>
        public AddTaskResult RemoveTask(int taskId)
        {
            return new AddTaskResult();
        }

        #endregion
    }
}
