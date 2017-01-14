using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using AutoMapper;
using WebGrease.Css.Extensions;

namespace MoviesTestPre
{
	public partial class Startup
	{
	    private IMapper InitializeMapper()
	    {
            var profileType = typeof(Profile);
            // Get an instance of each Profile in the executing assembly.
            var profiles = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => profileType.IsAssignableFrom(t)
                    && t.GetConstructor(Type.EmptyTypes) != null)
                .Select(Activator.CreateInstance)
                .Cast<Profile>();

            // Initialize AutoMapper with each instance of the profiles found.
            var config = new MapperConfiguration(cfg => profiles.ForEach(cfg.AddProfile));


            return config.CreateMapper();
        }

    }
}