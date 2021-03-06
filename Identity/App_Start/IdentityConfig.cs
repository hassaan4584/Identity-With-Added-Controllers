﻿using Identity.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Identity
{
    // This is useful if you do not want to tear down the database each time you run the application.
    // You want to create a new database if the Model changes
    // public class MyDbInitializer : DropCreateDatabaseIfModelChanges<ApplicationDbContext>


     public class MyDbInitializer : DropCreateDatabaseAlways<ApplicationDbContext>
         {
             protected override void Seed(ApplicationDbContext context)
             {
                 var UserManager = new UserManager<ApplicationUser>(new 

                                                UserStore<ApplicationUser>(context)); 

                 var RoleManager = new RoleManager<IdentityRole>(new 
                                          RoleStore<IdentityRole>(context));
      
                 string name = "Admin";
                 string password = "123456";
 
     
                //Create Role Admin if it does not exist
                if (!RoleManager.RoleExists(name))
                {
                    var roleresult = RoleManager.Create(new IdentityRole(name));
                }
     
                //Create User=Admin with password=123456
                var user = new ApplicationUser();
                user.UserName = name;
                var adminresult = UserManager.Create(user, password);
     
                //Add User Admin to Role Admin
                if (adminresult.Succeeded)
                {
                    var result = UserManager.AddToRole(user.Id, name);
                }
                base.Seed(context);
            }
        }




}