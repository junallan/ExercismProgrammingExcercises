module bob
  implicit none
contains

  function hey(statement)
    character(len=100) :: hey
    character(len=*), intent(in) :: statement
    logical :: is_lowercase_found
    logical :: is_uppercase_found
    logical :: is_yelling
    logical :: ends_with_question_mark

    is_lowercase_found = check_character_range(statement, 'a', 'z')
    is_uppercase_found = check_character_range(statement, 'A', 'Z')
    
    if (LEN_TRIM(statement) == 0) then
      hey = "Fine. Be that way!"
      return
    end if

    is_yelling = (.NOT. is_lowercase_found) .AND. is_uppercase_found

    ends_with_question_mark = LEN_TRIM(statement) > 0 .AND. statement(LEN_TRIM(statement):LEN_TRIM(statement)) == '?'

    if (ends_with_question_mark .AND. is_yelling) then
      hey = "Calm down, I know what I'm doing!"
    else if (ends_with_question_mark) then
      hey = "Sure."
    else if (is_yelling) then
      hey = "Whoa, chill out!"
    else
      hey = "Whatever."
    end if
  end function hey

  function check_character_range(str, lower_char, upper_char) result(is_found)
    character(len=*), intent(in) :: str
    character(len=1), intent(in) :: lower_char, upper_char
    logical :: is_found
    integer :: i

    is_found = .FALSE.
    do i = 1, len_trim(str)
      if (ichar(str(i:i)) >= ichar(lower_char) .AND. ichar(str(i:i)) <= ichar(upper_char)) then
        is_found = .TRUE.
        exit
      end if
    end do
  end function check_character_range

end module bob
