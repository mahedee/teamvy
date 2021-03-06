﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PMTool.Models;

namespace PMTool.Repository
{
    public class UnitOfWork : IDisposable
    {

        private PMToolContext context;
        public UnitOfWork()
        {
            context = new PMToolContext();
        }
        
        public UnitOfWork(PMToolContext _context)
        {
            this.context = _context;
        }



        private LabelRepository _labelRepository;

        public LabelRepository LabelRepository
        {
            get
            {

                if (this._labelRepository == null)
                {
                    this._labelRepository = new LabelRepository(context);
                }
                return _labelRepository;
            }
        }

        private TaskRepository _taskRepository;

        public TaskRepository TaskRepository
        {
            get
            {

                if (this._taskRepository == null)
                {
                    this._taskRepository = new TaskRepository(context);
                }
                return _taskRepository;
            }
        }

        private ProjectRepository _projectRepository;

        public ProjectRepository ProjectRepository
        {
            get
            {

                if (this._projectRepository == null)
                {
                    this._projectRepository = new ProjectRepository(context);
                }
                return _projectRepository;
            }
        }

        private PriorityRepository _priorityRepository;

        public PriorityRepository PriorityRepository
        {
            get
            {

                if (this._priorityRepository == null)
                {
                    this._priorityRepository = new PriorityRepository(context);
                }
                return _priorityRepository;
            }
        }

        private UserRepository _userRepository;

        public UserRepository UserRepository
        {
            get
            {

                if (this._userRepository == null)
                {
                    this._userRepository = new UserRepository(context);
                }
                return _userRepository;
            }
        }


        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
