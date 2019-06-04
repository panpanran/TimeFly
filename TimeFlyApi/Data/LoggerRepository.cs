using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeFlyApi.Models;

namespace TimeFlyApi.Data
{
    enum LogLevel { INFO, WARN, DEBUG, ERROR }

    public interface ILoggerRepository
    {
        Task<Logger> LogInfo(string message);
        Task<Logger> LogWarn(string message);
        Task<Logger> LogDebug(string message);
        Task<Logger> LogError(string message);
    }

    public class LoggerRepository : ILoggerRepository
    {
        private readonly DataContext _context;
        public LoggerRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Logger> LogInfo(string message)
        {
            Logger logger = new Logger();
            logger.Level = Convert.ToInt32(LogLevel.INFO);
            logger.Message = message;
            logger.CreatedDate = DateTime.Now;
            await _context.Loggers.AddAsync(logger);
            await _context.SaveChangesAsync();
            return logger;
        }

        public async Task<Logger> LogWarn(string message)
        {
            Logger logger = new Logger();
            logger.Level = Convert.ToInt32(LogLevel.WARN);
            logger.Message = message;
            logger.CreatedDate = DateTime.Now;
            await _context.Loggers.AddAsync(logger);
            await _context.SaveChangesAsync();
            return logger;
        }

        public async Task<Logger> LogDebug(string message)
        {
            Logger logger = new Logger();
            logger.Level = Convert.ToInt32(LogLevel.DEBUG);
            logger.Message = message;
            logger.CreatedDate = DateTime.Now;
            await _context.Loggers.AddAsync(logger);
            await _context.SaveChangesAsync();
            return logger;
        }

        public async Task<Logger> LogError(string message)
        {
            Logger logger = new Logger();
            logger.Level = Convert.ToInt32(LogLevel.ERROR);
            logger.Message = message;
            logger.CreatedDate = DateTime.Now;
            await _context.Loggers.AddAsync(logger);
            await _context.SaveChangesAsync();
            return logger;
        }
    }
}
