using AutoMapper;
using TaskManager.Application.Common.Mapping;
using Domain;

namespace TaskManager.Application.Notes.Queries.GetNoteList
{
    public class NoteLookup: IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookup>()
                .ForMember(noteL => noteL.Id
                , opt => opt.MapFrom(note => note.Id))
                .ForMember(noteL => noteL.Title
                , opt => opt.MapFrom(note => note.Title))
                .ForMember(noteL => noteL.Description
                , opt => opt.MapFrom(note => note.Description))
                .ForMember(noteL => noteL.Status
                , opt => opt.MapFrom(note => note.Status));
        }
    }
}
