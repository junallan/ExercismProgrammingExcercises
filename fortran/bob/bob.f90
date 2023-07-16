module bob
  implicit none
contains

  function hey(statement)
    character(100) :: hey
    character(len=*), intent(in) :: statement
    logical :: is_all_uppercase
    logical :: ends_with_question_mark
    integer :: i

    is_all_uppercase = .TRUE.

    do i = 1, len_trim(statement)
      if (ichar(statement(i:i)) >= ichar('a') .and. ichar(statement(i:i)) <= ichar('z')) then
          is_all_uppercase = .FALSE.
          exit   ! Exit the loop if a lowercase letter is found
      end if
    end do

    ends_with_question_mark = LEN_TRIM(statement) > 0 .and. statement(LEN_TRIM(statement):LEN_TRIM(statement)) == '?'

    if (ends_with_question_mark) then
      hey = "Sure."
    else if (is_all_uppercase) then
      hey = "Whoa, chill out!"
    else
      hey = "Whatever."
    end if
  end function hey

end module bob
