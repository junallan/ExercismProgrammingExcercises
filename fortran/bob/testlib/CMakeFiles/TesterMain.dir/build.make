# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.26

# Delete rule output on recipe failure.
.DELETE_ON_ERROR:

#=============================================================================
# Special targets provided by cmake.

# Disable implicit rules so canonical targets will work.
.SUFFIXES:

# Disable VCS-based implicit rules.
% : %,v

# Disable VCS-based implicit rules.
% : RCS/%

# Disable VCS-based implicit rules.
% : RCS/%,v

# Disable VCS-based implicit rules.
% : SCCS/s.%

# Disable VCS-based implicit rules.
% : s.%

.SUFFIXES: .hpux_make_needs_suffix_list

# Command-line flag to silence nested $(MAKE).
$(VERBOSE)MAKESILENT = -s

#Suppress display of executed commands.
$(VERBOSE).SILENT:

# A target that is always out of date.
cmake_force:
.PHONY : cmake_force

#=============================================================================
# Set environment variables for the build.

# The shell in which to execute make rules.
SHELL = /bin/sh

# The CMake executable.
CMAKE_COMMAND = /opt/homebrew/Cellar/cmake/3.26.4/bin/cmake

# The command to remove a file.
RM = /opt/homebrew/Cellar/cmake/3.26.4/bin/cmake -E rm -f

# Escaping for special characters.
EQUALS = =

# The top-level source directory on which CMake was run.
CMAKE_SOURCE_DIR = /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob

# The top-level build directory on which CMake was run.
CMAKE_BINARY_DIR = /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob

# Include any dependencies generated for this target.
include testlib/CMakeFiles/TesterMain.dir/depend.make
# Include any dependencies generated by the compiler for this target.
include testlib/CMakeFiles/TesterMain.dir/compiler_depend.make

# Include the progress variables for this target.
include testlib/CMakeFiles/TesterMain.dir/progress.make

# Include the compile flags for this target's objects.
include testlib/CMakeFiles/TesterMain.dir/flags.make

testlib/CMakeFiles/TesterMain.dir/TesterMain.f90.o: testlib/CMakeFiles/TesterMain.dir/flags.make
testlib/CMakeFiles/TesterMain.dir/TesterMain.f90.o: testlib/TesterMain.f90
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --progress-dir=/Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob/CMakeFiles --progress-num=$(CMAKE_PROGRESS_1) "Building Fortran object testlib/CMakeFiles/TesterMain.dir/TesterMain.f90.o"
	cd /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob/testlib && /opt/homebrew/bin/gfortran $(Fortran_DEFINES) $(Fortran_INCLUDES) $(Fortran_FLAGS) -c /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob/testlib/TesterMain.f90 -o CMakeFiles/TesterMain.dir/TesterMain.f90.o

testlib/CMakeFiles/TesterMain.dir/TesterMain.f90.i: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Preprocessing Fortran source to CMakeFiles/TesterMain.dir/TesterMain.f90.i"
	cd /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob/testlib && /opt/homebrew/bin/gfortran $(Fortran_DEFINES) $(Fortran_INCLUDES) $(Fortran_FLAGS) -E /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob/testlib/TesterMain.f90 > CMakeFiles/TesterMain.dir/TesterMain.f90.i

testlib/CMakeFiles/TesterMain.dir/TesterMain.f90.s: cmake_force
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green "Compiling Fortran source to assembly CMakeFiles/TesterMain.dir/TesterMain.f90.s"
	cd /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob/testlib && /opt/homebrew/bin/gfortran $(Fortran_DEFINES) $(Fortran_INCLUDES) $(Fortran_FLAGS) -S /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob/testlib/TesterMain.f90 -o CMakeFiles/TesterMain.dir/TesterMain.f90.s

# Object files for target TesterMain
TesterMain_OBJECTS = \
"CMakeFiles/TesterMain.dir/TesterMain.f90.o"

# External object files for target TesterMain
TesterMain_EXTERNAL_OBJECTS =

testlib/libTesterMain.a: testlib/CMakeFiles/TesterMain.dir/TesterMain.f90.o
testlib/libTesterMain.a: testlib/CMakeFiles/TesterMain.dir/build.make
testlib/libTesterMain.a: testlib/CMakeFiles/TesterMain.dir/link.txt
	@$(CMAKE_COMMAND) -E cmake_echo_color --switch=$(COLOR) --green --bold --progress-dir=/Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob/CMakeFiles --progress-num=$(CMAKE_PROGRESS_2) "Linking Fortran static library libTesterMain.a"
	cd /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob/testlib && $(CMAKE_COMMAND) -P CMakeFiles/TesterMain.dir/cmake_clean_target.cmake
	cd /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob/testlib && $(CMAKE_COMMAND) -E cmake_link_script CMakeFiles/TesterMain.dir/link.txt --verbose=$(VERBOSE)

# Rule to build all files generated by this target.
testlib/CMakeFiles/TesterMain.dir/build: testlib/libTesterMain.a
.PHONY : testlib/CMakeFiles/TesterMain.dir/build

testlib/CMakeFiles/TesterMain.dir/clean:
	cd /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob/testlib && $(CMAKE_COMMAND) -P CMakeFiles/TesterMain.dir/cmake_clean.cmake
.PHONY : testlib/CMakeFiles/TesterMain.dir/clean

testlib/CMakeFiles/TesterMain.dir/depend:
	cd /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob && $(CMAKE_COMMAND) -E cmake_depends "Unix Makefiles" /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob/testlib /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob/testlib /Users/junallanparreno/Projects/ExercismProgrammingExcercises/fortran/bob/testlib/CMakeFiles/TesterMain.dir/DependInfo.cmake --color=$(COLOR)
.PHONY : testlib/CMakeFiles/TesterMain.dir/depend

