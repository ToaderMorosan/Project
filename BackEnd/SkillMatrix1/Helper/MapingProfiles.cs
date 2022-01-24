using AutoMapper;
using SkillMatrix1.Dto;
using SkillMatrix1.Models;

namespace SkillMatrix1.Helper
{
    public class MapingProfiles : Profile 
    {
        public MapingProfiles()
        {
            CreateMap<Employee, EmployeeDto>();
            CreateMap<Interest, InterestDto>();
            CreateMap<Study, StudyDto>();
            CreateMap<Skill, SkillDto>();
            CreateMap<DevTool, DevToolDto>();
            CreateMap<EmployeeDto, Employee>();
            CreateMap<StudyDto, Study>();
            CreateMap<SkillDto, Skill>();
            CreateMap<InterestDto, Interest>();
            CreateMap<DevToolDto, DevTool>();
        }
    }
}
