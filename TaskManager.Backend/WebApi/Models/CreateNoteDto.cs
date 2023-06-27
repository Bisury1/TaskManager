using AutoMapper;
using System.ComponentModel.DataAnnotations;
using TaskManager.Application.Common.Mapping;
using TaskManager.Application.Notes.Command.CreateNote;

namespace TaskManager.WebApi.Models
{
    public class CreateNoteDto : IMapWith<CreateNoteCommand>
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateNoteDto, CreateNoteCommand>()
                .ForMember(noteCommand => noteCommand.Title,
                    opt => opt.MapFrom(noteDto => noteDto.Title))
                .ForMember(noteCommand => noteCommand.Description,
                    opt => opt.MapFrom(noteDto => noteDto.Description))
                .ForMember(noteCommand => noteCommand.Status,
                    opt => opt.MapFrom(noteDto => noteDto.Status));
        }
    }
}
