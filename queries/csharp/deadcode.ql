import csharp

from Stmt s, Stmt prev
where
  prev.getBasicBlock() = s.getBasicBlock() and
  prev.getIndexInBlock() < s.getIndexInBlock() and
  prev.terminatesExecution()
select s, "Este código es inalcanzable (dead code)."
