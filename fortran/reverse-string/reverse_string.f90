module reverse_string
  implicit none
contains
  function reverse(input) result(reversed)
    character(*), intent(in) :: input
    character(len=len(input)) :: reversed
    integer :: i
    integer :: input_length

    input_length = len(input)

    reversed = ""

    do i = input_length, 1, -1
      reversed(input_length-i+1:input_length-i+1) = input(i:i)
    end do
  end function
end module