using AutoMapper;
using MFER.App.ViewModels;
using MFER.Business.Models;

namespace MFER.App.AutoMapper;

public class AutoMapperConfig : Profile
{
    public AutoMapperConfig()
    {
        CreateMap<Contato, ContatoViewModel>();
    }
}