using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using Yamama.Models;
using Yamama.Repository;

namespace Yamama.Services
{
    public class ProjectService : IProject
    {

        //create instance from dbcontext class
        private readonly yamamadbContext _db;
        public ProjectService(yamamadbContext db)
        {
            _db = db;
        }

        // function to add new project
        public async Task<int> AddProjectAsync(Project project)
        {
            int result = 0;
            // add new project
            await _db.Project.AddAsync(project);
            //if the operation succecced return 1
            result += 1;
            return result;
        }

        //function to delete project by id 
        public async Task <int> DeleteProjectAsync(int id)
        {
            int result = 0;
            //check if the dbcontext is not null
            if (_db != null)
            {
                // if not.. find the specified project
                var project =  await _db.Project.FirstOrDefaultAsync(p => p.Idproject == id);
                //check the returned value is not null
                if (project != null)

                // if it not null delete the specified project
                 _db.Project.Remove(project);
                //commit the changes on database
                _db.SaveChanges();
                //if the operation succecced return 1
                result += 1;
                return result;

            }

            return result;
        }

        //function to get specific project by id
        public async Task <Project> GetProject(int id)
        {
            //get all projects
            var project = await _db.Project.FirstOrDefaultAsync(f => f.Idproject == id);
            return project;
        }

        // function to get all projects
        public async Task <List<Project>> GetProjects()
        {
            //check if the dbcontext is not null
            if (_db != null)
            {
                // if not find all projects
                return await  _db.Project.ToListAsync();
            }

            return null;
        }
        //function to edit records from project table
        public async Task <int> UpdateProject(int id, Project project)
        {
            int result = 0;
            //check if the dbcontext is not null
            if (_db != null)
            {
                //if not create a new object from  specific model class  
                Project existProject = await _db.Project.Where(p => p.Idproject == id).FirstOrDefaultAsync();
                //check the returned object  is not null
                if (existProject != null)
                {
                    existProject.Name = project.Name;
                    existProject.Owner = project.Owner;
                    existProject.Location = project.Location;
                    existProject.Space = project.Space;
                    existProject.Cost = project.Cost;
                    existProject.Contractor = project.Contractor;
                    existProject.Consultant = project.Consultant;
                    existProject.Status = project.Status;
                    existProject.Details = project.Details;
                    existProject.Notes = project.Notes;
                    existProject.InformationSource = project.InformationSource;
                }
                //edit the returned object 
                _db.Project.Update(existProject);
                //commit changes
                _db.SaveChanges();
                result += 1;
                return result;

            }
            return result;
         
        }
    }
}
