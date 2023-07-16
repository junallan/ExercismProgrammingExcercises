module bob
  implicit none
contains

  function hey(statement)
    character(100) :: hey
    character(len=*), intent(in) :: statement
    logical :: is_lowercase_found
    logical :: is_uppercase_found
    logical :: is_yelling
    logical :: ends_with_question_mark
    integer :: i

    is_lowercase_found = .FALSE.
    is_uppercase_found = .FALSE.

    do i = 1, len_trim(statement)
      if (ichar(statement(i:i)) >= ichar('a') .and. ichar(statement(i:i)) <= ichar('z')) then
          is_lowercase_found = .TRUE.
          exit   ! Exit the loop if a lowercase letter is found
      else if (ichar(statement(i:i)) >= ichar('A') .and. ichar(statement(i:i)) <= ichar('Z')) then
          is_uppercase_found = .TRUE.
      end if
    end do

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

end module bob
