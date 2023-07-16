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

    is_lowercase_found = check_lowercase(statement)
    is_uppercase_found = check_uppercase(statement)
    
    if (LEN_TRIM(statement) == 0) then
      hey = "Fine. Be that way!"
      return
    end if

    is_yelling = (.NOT. is_lowercase_found) .and. is_uppercase_found

    ends_with_question_mark = LEN_TRIM(statement) > 0 .and. statement(LEN_TRIM(statement):LEN_TRIM(statement)) == '?'

    if (ends_with_question_mark .and. is_yelling) then
      hey = "Calm down, I know what I'm doing!"
    else if (ends_with_question_mark) then
      hey = "Sure."
    else if (is_yelling) then
      hey = "Whoa, chill out!"
    else
      hey = "Whatever."
    end if
  end function hey

  function check_lowercase(str) result(is_lowercase)
    character(len=*), intent(in) :: str
    logical :: is_lowercase
    integer :: i

    is_lowercase = .FALSE.
    do i = 1, len_trim(str)
      if (ichar(str(i:i)) >= ichar('a') .and. ichar(str(i:i)) <= ichar('z')) then
        is_lowercase = .TRUE.
        exit
      end if
    end do
  end function check_lowercase

  function check_uppercase(str) result(is_uppercase)
    character(len=*), intent(in) :: str
    logical :: is_uppercase
    integer :: i

    is_uppercase = .FALSE.
    do i = 1, len_trim(str)
      if (ichar(str(i:i)) >= ichar('A') .and. ichar(str(i:i)) <= ichar('Z')) then
        is_uppercase = .TRUE.
        exit
      end if
    end do
  end function check_uppercase
end module bob
