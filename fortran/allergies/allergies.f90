module allergies
  implicit none

contains

  logical function allergicTo(allergy_str, allergy_key)
    character(len=*), intent(in) :: allergy_str
    integer, intent(in) :: allergy_key
   
    if (index(allergicList(allergy_key), allergy_str) > 0) then
      allergicTo = .true.
    else
      allergicTo = .false. 
    endif
  end function


  function allergicList(allergy_key) result(allergies)
    integer, intent(in) :: allergy_key
    character(len=100) :: allergies
    
    allergies = ""

    if (btest(allergy_key, 0)) then
      allergies = trim(allergies) // " " // "eggs"
    endif

    if (btest(allergy_key, 1)) then
      allergies = trim(allergies) // " " // "peanuts"
    endif

    if (btest(allergy_key, 2)) then
      allergies = trim(allergies) // " " // "shellfish"
    endif

    if (btest(allergy_key, 3)) then
      allergies = trim(allergies) // " " // "strawberries"
    endif

    if (btest(allergy_key, 4)) then
      allergies = trim(allergies) // " " // "tomatoes"
    endif

    if (btest(allergy_key, 5)) then
      allergies = trim(allergies) // " " // "chocolate"
    endif

    if (btest(allergy_key, 6)) then
      allergies = trim(allergies) // " " // "pollen"
    endif

    if (btest(allergy_key, 7)) then
      allergies = trim(allergies) // " " // "cats"
    endif

    allergies = adjustl(allergies)
  end function
end module
