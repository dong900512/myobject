﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewInfoWeb.Appcode
{
    /// <summary>
    /// 日志封装
    /// </summary>
    public class Logger
    {
        NLog.Logger logger;

        private Logger(NLog.Logger logger)
        {
            this.logger = logger;
        }

        public Logger(string name)
            : this(NLog.LogManager.GetLogger(name))
        {
        }

        public static Logger Default { get; private set; }
        static Logger()
        {
            Default = new Logger(NLog.LogManager.GetCurrentClassLogger());
        }

        public void Debug(string msg, params object[] args)
        {
            logger.Debug(msg, args);
        }

        public void Debug(string msg, Exception err)
        {
            logger.Debug(msg, err);
        }

        public void Info(string msg, params object[] args)
        {
            logger.Info(msg, args);
        }

        public void Info(string msg, Exception err)
        {
            logger.Info(msg, err);
        }

        public void Trace(string msg, params object[] args)
        {
            logger.Trace(msg, args);
        }

        public void Trace(string msg, Exception err)
        {
            logger.Trace(msg, err);
        }

        public void Error(string msg, params object[] args)
        {
            logger.Error(msg, args);
        }

        public void Error(string msg, Exception err)
        {
            logger.Error(msg, err);
        }

        public void Fatal(string msg, params object[] args)
        {
            logger.Fatal(msg, args);
        }

        public void Fatal(string msg, Exception err)
        {
            logger.Fatal(msg, err);
        }
    }
}