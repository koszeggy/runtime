set(SOURCES
  test1.c
)

add_executable(paltest_finitef_test1
  ${SOURCES}
)

add_dependencies(paltest_finitef_test1 coreclrpal)

target_link_libraries(paltest_finitef_test1
  ${COMMON_TEST_LIBRARIES}
)
