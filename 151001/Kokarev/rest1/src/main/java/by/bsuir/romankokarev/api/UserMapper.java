package by.bsuir.romankokarev.api;

import by.bsuir.romankokarev.impl.bean.User;
import by.bsuir.romankokarev.impl.dto.UserRequestTo;
import by.bsuir.romankokarev.impl.dto.UserResponseTo;
import org.mapstruct.Mapper;
import org.mapstruct.factory.Mappers;

@Mapper
public interface UserMapper {
    UserMapper INSTANCE = Mappers.getMapper(UserMapper.class);
    UserResponseTo UserToUserResponseTo(User user);
    UserRequestTo UserToUserRequestTo(User user);
    User UserResponseToToUser(UserResponseTo userResponseTo);
    User UserRequestToToUser(UserRequestTo userRequestTo);
}
