# CMAKE generated file: DO NOT EDIT!
# Generated by "Unix Makefiles" Generator, CMake Version 3.26

# Note that incremental build could trigger a call to cmake_copy_f90_mod on each re-build
CMakeFiles/reverse-string.dir/reverse_string.f90.o.provides.build: CMakeFiles/reverse-string.dir/reverse_string.mod.stamp
CMakeFiles/reverse-string.dir/reverse_string.mod.stamp: CMakeFiles/reverse-string.dir/reverse_string.f90.o
	$(CMAKE_COMMAND) -E cmake_copy_f90_mod reverse_string.mod CMakeFiles/reverse-string.dir/reverse_string.mod.stamp GNU
CMakeFiles/reverse-string.dir/reverse_string.f90.o.provides.build:
	$(CMAKE_COMMAND) -E touch CMakeFiles/reverse-string.dir/reverse_string.f90.o.provides.build
CMakeFiles/reverse-string.dir/build: CMakeFiles/reverse-string.dir/reverse_string.f90.o.provides.build
CMakeFiles/reverse-string.dir/reverse_string_test.f90.o: CMakeFiles/reverse-string.dir/reverse_string.mod.stamp
CMakeFiles/reverse-string.dir/reverse_string_test.f90.o: testlib/CMakeFiles/TesterMain.dir/testermain.mod.stamp
