/**
 * Autogenerated by Thrift Compiler (0.9.1)
 *
 * DO NOT EDIT UNLESS YOU ARE SURE THAT YOU KNOW WHAT YOU ARE DOING
 *  @generated
 */
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Thrift;
using Thrift.Collections;
using System.Runtime.Serialization;
using Thrift.Protocol;
using Thrift.Transport;

namespace StormThrift
{

  #if !SILVERLIGHT
  [Serializable]
  #endif
  public partial class ExecutorInfo : TBase
  {

    public int Task_start { get; set; }

    public int Task_end { get; set; }

    public ExecutorInfo() {
    }

    public ExecutorInfo(int task_start, int task_end) : this() {
      this.Task_start = task_start;
      this.Task_end = task_end;
    }

    public void Read (TProtocol iprot)
    {
      bool isset_task_start = false;
      bool isset_task_end = false;
      TField field;
      iprot.ReadStructBegin();
      while (true)
      {
        field = iprot.ReadFieldBegin();
        if (field.Type == TType.Stop) { 
          break;
        }
        switch (field.ID)
        {
          case 1:
            if (field.Type == TType.I32) {
              Task_start = iprot.ReadI32();
              isset_task_start = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          case 2:
            if (field.Type == TType.I32) {
              Task_end = iprot.ReadI32();
              isset_task_end = true;
            } else { 
              TProtocolUtil.Skip(iprot, field.Type);
            }
            break;
          default: 
            TProtocolUtil.Skip(iprot, field.Type);
            break;
        }
        iprot.ReadFieldEnd();
      }
      iprot.ReadStructEnd();
      if (!isset_task_start)
        throw new TProtocolException(TProtocolException.INVALID_DATA);
      if (!isset_task_end)
        throw new TProtocolException(TProtocolException.INVALID_DATA);
    }

    public void Write(TProtocol oprot) {
      TStruct struc = new TStruct("ExecutorInfo");
      oprot.WriteStructBegin(struc);
      TField field = new TField();
      field.Name = "task_start";
      field.Type = TType.I32;
      field.ID = 1;
      oprot.WriteFieldBegin(field);
      oprot.WriteI32(Task_start);
      oprot.WriteFieldEnd();
      field.Name = "task_end";
      field.Type = TType.I32;
      field.ID = 2;
      oprot.WriteFieldBegin(field);
      oprot.WriteI32(Task_end);
      oprot.WriteFieldEnd();
      oprot.WriteFieldStop();
      oprot.WriteStructEnd();
    }

    public override string ToString() {
      StringBuilder sb = new StringBuilder("ExecutorInfo(");
      sb.Append("Task_start: ");
      sb.Append(Task_start);
      sb.Append(",Task_end: ");
      sb.Append(Task_end);
      sb.Append(")");
      return sb.ToString();
    }

  }

}
